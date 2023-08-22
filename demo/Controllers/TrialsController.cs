using demo.Data;
using demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace demo.Controllers
{
    [ApiController]
    [Route("app/[controller]")]
    public class TrialsController : Controller
    { 
        private readonly ContextApplication dbContext;

        public TrialsController(ContextApplication dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetTrials()
        {
            return Ok(await dbContext.trials.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> AddTrial(AddTrialRequest AddTrialRequest)
        {
            var trial = new trial()
            {
                Id = Guid.NewGuid(),
                Name = AddTrialRequest.Name,
                BirthDate = AddTrialRequest.BirthDate,
            };
            await dbContext.trials.AddAsync(trial);
            await dbContext.SaveChangesAsync();
            return Ok(trial);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await dbContext.trials.FindAsync(id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var result= await dbContext.trials.FindAsync(id);
            if (result!= null)
            {
                dbContext.Remove(result);
                await dbContext.SaveChangesAsync();
                return Ok(result);
            }
            return NotFound();

        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateTrial([FromRoute] Guid id, trial trial)
        {
            var res = await dbContext.trials.FindAsync(id);
            if (res!=null)
            {
                
                res.Name = trial.Name;
                res.BirthDate = trial.BirthDate;

                await dbContext.SaveChangesAsync();
                return Ok(res);
            }

            return NotFound();


        }
    }
}
