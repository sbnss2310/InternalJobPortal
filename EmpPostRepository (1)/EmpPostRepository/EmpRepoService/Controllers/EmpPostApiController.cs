using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using EmpPostRepository;
using EmpPostRepository.Repos;

namespace EmpRepoService.Controllers
{
    //[Route("api/[controller]")]
    
    public class EmpPostApiController : ApiController
    {
        IEmpRepo repo = new EmpRepo();
        [HttpGet]
        
      //  [Route("api/sss")]
        public async Task<IHttpActionResult> GetAll()
        {
            List<EmpPost> post = await repo.GetAllPostsAsync();
            return Ok<List<EmpPost>>(post);
        }
        [HttpGet]
        [Route("{postId}")]
        public async Task<IHttpActionResult> GetOne(string postId)
        {
            try
            {
                EmpPost ePost = await repo.GetPostbyIdAsync(postId);

                return Ok(ePost);
            }
            catch (Exception ex)
            {
                Console.WriteLine("not found");
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IHttpActionResult> Post(EmpPost empPost)
        {

            await repo.InsertPostAsync(empPost);
            return Created<EmpPost>("/api/empPostApi", empPost);

        }
        [HttpPut]
        [Route("{postId}")]
        public async Task<IHttpActionResult> Update(string postId, EmpPost empPost)
        {
            await repo.UpdatePostAsync(postId, empPost);
            return Ok(empPost);
        }
        [HttpDelete]
        [Route("{postId}")]
        public async Task<IHttpActionResult> Delete(string postId)
        {
            await repo.DeletePostAsync(postId);
            return Ok();
        }

    }
}
