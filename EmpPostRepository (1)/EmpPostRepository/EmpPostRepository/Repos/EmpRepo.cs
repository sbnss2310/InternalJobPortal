using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpPostRepository.Repos
{
    public class EmpRepo : IEmpRepo
    {
        EmpPostsDBEntities ent = new EmpPostsDBEntities();
        public async Task DeletePostAsync(string postId)    
        {
            EmpPost empPost = await GetPostbyIdAsync(postId);
            ent.EmpPosts.Remove(empPost);
            await ent.SaveChangesAsync();
        }

        public async Task<List<EmpPost>> GetAllPostsAsync()
        {
            List<EmpPost> posts = await ent.EmpPosts.ToListAsync();
            return posts;
        }
        public async Task<EmpPost> GetPostbyIdAsync(string postId)
        {
            try
            {
                EmpPost post = await(from p in ent.EmpPosts where p.PostId == postId select p).FirstAsync();
                return post;
            }
            catch (Exception)
            {
                throw new Exception("No such post");
            }
        }

        public async Task<List<EmpPost>> GetPostsByEmpIdAsync(string empId)
        {
            
           
                List<EmpPost> posts = await(from p in ent.EmpPosts where p.EmpId == empId select p).ToListAsync();
            if (posts.Count > 0)
                return posts;
            else
                throw new Exception("Employee has no applications");
            
        }

        public async Task<List<EmpPost>> GetPostsbyIdAsync(string postId)
        {
            List<EmpPost> posts = await(from p in ent.EmpPosts where p.PostId == postId select p).ToListAsync();
            if (posts.Count > 0)
                return posts;
            else
                throw new Exception("No posts found");
        }

        public async Task InsertPostAsync(EmpPost empPost)
        {
            ent.EmpPosts.Add(empPost);
            await ent.SaveChangesAsync();
        }

        public async Task UpdatePostAsync(string postId, EmpPost empPost)
        {
            EmpPost record = await GetPostbyIdAsync(postId);
            record.ApplicationStatus = empPost.ApplicationStatus;
            await ent.SaveChangesAsync();
        }
    }
}
