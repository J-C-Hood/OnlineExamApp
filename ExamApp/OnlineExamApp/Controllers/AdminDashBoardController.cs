using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CommonProject.AdminDashBoardModel;
using CommonProject.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using OnlineExamApp.Common;
using OnlineExamApp.Model;
using OnlineExamApp.Model.AdminDashBoardModel;
using OnlineExamApp.Services;

namespace OnlineExamApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminDashBoardController : ControllerBase
    {
        private IAdminDashBoard _adminService;
        private IMapper _mapper;
        private examlibrarydbContext _context;

        public AdminDashBoardController(IAdminDashBoard adminService,
            IMapper mapper, examlibrarydbContext context)
        {
            _adminService = adminService;
            _mapper = mapper;
            _context = context;
        }

        // GET: api/AdminDashBoard
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Simtest>>> GetSimtest()
        //{
        //    return await _context.Simtest.ToListAsync();
        //}

        // GET: api/AdminDashBoard/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Simtest>> GetSimtest(int id)
        //{
        //    var simtest = await _context.Simtest.FindAsync(id);

        //    if (simtest == null)
        //    {
        //        return NotFound();
        //    }

        //    return simtest;
        //}

        // PUT: api/AdminDashBoard/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSimtest(int id, UpdateTestModel model)
        {
            if (id != model.TestId)
            {
                return BadRequest();
            }
            // map model to entity
            var simtest = _mapper.Map<Simtest>(model);

            _context.Entry(simtest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SimtestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AdminDashBoard
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<SimulateTestModel>>> GetSimtest(string Id)
        {
            // map model to entity
            var d = await _context.Simtest.Where(x => x.EmailId == Id).ToListAsync();
            List<SimulateTestModel> sm = new List<SimulateTestModel>();
            int count = 1;
            foreach(var item in d){

                SimulateTestModel md = new SimulateTestModel();
                md.SerialNumber = count++;
                md.Percentage = item.Percentage;
                md.TestId = item.TestId;
                md.TestName = item.TestName;
                sm.Add(md);
            }

            return sm;
        }

        // POST: api/AdminDashBoard
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("addtest")]
        public  IActionResult PostSimtest([FromBody]AddTestModel model)
        {
            // map model to entity
            var simtest = _mapper.Map<Simtest>(model);
            _context.Simtest.Add(simtest);
             _context.SaveChangesAsync();
            return Ok(new RegisterResult { Successful = true });

            // return CreatedAtAction("GetSimtest", new { id = simtest.TestId }, simtest);
        }

        // POST: api/AdminDashBoard
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("addquestion")]
        public IActionResult AddQuestion([FromBody] AddQuestionModel qnModel)
        {
            try
            {
                // map model to entity
                Questions qns = new Questions();
                qns.CorrectAnswer = qnModel.CorrectAnswer;
                qns.TestId = qnModel.TestId;
                qns.Question = qnModel.Question;
                Choicetable ops = new Choicetable();
                ops.ChoiceOne = qnModel.ChoiceOne;
                ops.ChoiceTwo = qnModel.ChoiceTwo;
                ops.ChoiceThree = qnModel.ChoiceThree;
                ops.ChoiceFour = qnModel.CorrectAnswer;
                //ops.QuestionId
                _adminService.AddQuestion(qns, ops);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        
        [HttpPost("assign")]
        public IActionResult Assign([FromBody] AssigntoStudentModel model)
        {
            // map model to entity
          //  var user = _mapper.Map<Customeraccount>(model);

            try
            {
                // create user
                _adminService.AssignToStudent(model);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE: api/AdminDashBoard/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Simtest>> DeleteSimtest(int id)
        {
            var simtest = await _context.Simtest.FindAsync(id);
            if (simtest == null)
            {
                return NotFound();
            }

            _context.Simtest.Remove(simtest);
            await _context.SaveChangesAsync();

            return simtest;
        }

        private bool SimtestExists(int id)
        {
            return _context.Simtest.Any(e => e.TestId == id);
        }
    }
}
