using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace WebApplication4
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObjectDapperController : ControllerBase
    {
        private readonly YourDataAccessClass dataAccess;

        public ObjectDapperController(YourDataAccessClass dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        [HttpPost("BulkInsertTest")]
        public IActionResult BulkInsertTest()
        {
            try
            {
                // Create 500,000 anonymous objects
                List<ObjectDapperDTO> objectsToInsert = new List<ObjectDapperDTO>();
                for (int i = 0; i < 1000000; i++) // 89026
                {
                    objectsToInsert.Add(new ObjectDapperDTO
                    {
                        Name = $"Name{i}",
                        Description = $"Description{i}"
                    });
                }
                Stopwatch sw = Stopwatch.StartNew();
                // Perform the bulk insert
                dataAccess.BulkInsertObjects(objectsToInsert);
                sw.Stop();
                long number = sw.ElapsedMilliseconds;
                return Ok(number);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
