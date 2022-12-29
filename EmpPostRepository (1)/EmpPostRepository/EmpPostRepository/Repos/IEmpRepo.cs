using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EmpPostRepository.Repos
{
    public interface IEmpRepo
    {
        Task<List<EmpPost>> GetAllPostsAsync();

        Task<List<EmpPost>> GetPostsbyIdAsync(string postId);
        Task<List<EmpPost>> GetPostsByEmpIdAsync(string empId);
        Task<EmpPost> GetPostbyIdAsync(string postId);
        //emps
        Task InsertPostAsync(EmpPost empPost);
        //manager
        Task UpdatePostAsync(string postId, EmpPost empPost);
        //manager
        Task DeletePostAsync(string postId);
    }
}
