namespace SchedApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using SchedApi.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleItemController : ControllerBase
    {
        private readonly ScheduleItemContext m_pDbContext;

        public ScheduleItemController(ScheduleItemContext pDbContext)
        {
            // assert the default context instance through arguments
            m_pDbContext = pDbContext;
        }

        // GET: api/<ScheduleItemController>
        [HttpGet]
        public async Task<ActionResult<List<ScheduleItemInfo>>> GetAll()
        {
            if (m_pDbContext == null)
                return new List<ScheduleItemInfo>();

            // return full list
            return await m_pDbContext.ScheduleItems.ToListAsync();
        }

        // GET api/<ScheduleItemController>/5
        [HttpGet("{id}", Name = "GetScheduleItem")]
        public async Task<ActionResult<ScheduleItemInfo>> GetById(long id)
        {
            if (m_pDbContext == null)
                return NotFound();

            // try to find the target item using the id
            ScheduleItemInfo? pData = await m_pDbContext.ScheduleItems.FindAsync(id);
            if (pData == null)
                return NotFound();

            return pData;
        }

        // POST api/<ScheduleItemController>
        [HttpPost]
        public async Task<IActionResult> Create(ScheduleItemInfo pData)
        {
            // insert the new item to the list
            await m_pDbContext.ScheduleItems.AddAsync(pData);
            await m_pDbContext.SaveChangesAsync();

            // return the new item to the request
            return CreatedAtRoute("GetScheduleItem", new { id = pData.Id }, pData);
        }


        // DELETE api/<ScheduleItemController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, ScheduleItemInfo pNewData)
        {
            if (m_pDbContext == null)
                return NotFound();

            // try to find the target item using the id
            ScheduleItemInfo? pData = await m_pDbContext.ScheduleItems.FindAsync(id);
            if (pData == null)
                return NotFound();

            // update the informations on stored data
            pData.Value = pNewData.Value;
            pData.Phone = pNewData.Phone;
            pData.Status = pNewData.Status;
            pData.Date = pNewData.Date;

            // process update on context list
            m_pDbContext.ScheduleItems.Update(pData);
            await m_pDbContext.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/<ScheduleItemController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            if (m_pDbContext == null)
                return NotFound();

            // try to find the target item using the id
            ScheduleItemInfo? pData = await m_pDbContext.ScheduleItems.FindAsync(id);
            if (pData == null)
                return NotFound();

            // if we find the object, process the delete operation
            m_pDbContext.ScheduleItems.Remove(pData);
            await m_pDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
