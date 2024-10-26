using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;
using System.Diagnostics.Contracts;
using WebAppLesson1.DTO;
using WinFormsApp1.Context;
using WinFormsApp1.Models;
using WinFormsApp1.Repository;
using WinFormsApp1.Service;
using Contract = WinFormsApp1.Models.Contract;

namespace WebAppLesson1.Controllers
{
    public class AllStudentController : Controller
    {
        private readonly static AppDbContext context = new AppDbContext();
        AppService service = new AppService(
            new GroupRepository(context),
            new ContractRepository(context),
            new StudentRepository(context),
            new WorkTableRepository(context),
            new SubjectRepository(context));
        public IActionResult Index()
        {
            return View();
        }
        #region Get
        [HttpGet("GetGroups")]
        public async Task<IEnumerable<Group>> GetGroups()
        {
            return await service.GetAllGroup();
        }

        [HttpGet("GetContracts")]
        public async Task<IEnumerable<Contract>> GetContracts()
        {
            return await service.GetAllContract();
        }
      

        [HttpGet("GetStudents")]
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await service.GetAllStudent();
        }
       
        [HttpGet("GetSubjects")]
        public async Task<IEnumerable<Subject>> GetSubjects()
        {
            return await service.GetAllSubject();
        }
        [HttpGet("GetWorkTables")]
        public async Task<IEnumerable<WorkTable>> GetWorkTables()
        {
            return await service.GetAllWorkTable();
        }
        #endregion
        #region Create
        [HttpPost("CreateStudent")]
        public async Task<Student> CreateStudents(StudentDto studentDto)
        {
            return await service.CreateStudent(studentDto);
        }
        [HttpPost("CreateContract")]
        public async Task<Contract> CreateContract(string name)
        {
            return await service.CreateContract(name);
        }
        
        [HttpPost("CreateGroup")]
        public async Task<Group> CreateGroups(string name)
        {
            return await service.CreateGroup(name);

        }
        [HttpPost("CreateSubject")]
        public async Task<Subject>CreateSubject(string name)
        {
            return await service.CreateSubject(name);
        }
        [HttpPost("CreateWorkTable")]
        public async Task<WorkTable>CreateWorkTable(WorkTableDto workTable)
        {
            return await service.AddWorkTable(workTable);

        }
        #endregion
        #region Update
        [HttpPatch("UpdateGroup")]
        public async Task<Group>UpdateGroup(Group group)
        {
            return await service.UpdateGroup(group);
        }
        [HttpPatch("UpdateSubject")]
        public async Task<Subject>UpdateSubject(Subject subject)
        {
            return await service.Updatesubject(subject);
        }
        [HttpPatch("UpdateContract")]
        public async Task<Contract>UpdateContract(Contract contract)
        {
            return await service.UpdateContract(contract);
        }
        [HttpPut("Updatestudent")]
        public async Task<Student> UpdateStudents(int id, StudentDto student)
        {
            return await service.UpdateStudent(id, student);
        }
        [HttpPut("UpdateWorkTable")]
        public async Task<WorkTable>UpdateWorkTable(int id ,WorkTableDto workTable)
        {
            return await service.UpdateWorkTable(id, workTable);
        }
        #endregion
        #region Delete
        [HttpDelete("deleteGroup")]
        public async Task DeleteGroup(int id)
        {
             await service.DeleteGroup(id);
        }
        [HttpDelete("DeleteSubject")]
        public async Task DeleteSubject(int id)
        {
            await service.Deletesubject(id);
        }
        [HttpDelete("deleteContract")]
        public async Task DeleteContract(int  id)
        {
             await service.DeleteContract(id);
        }
        [HttpDelete("DeleteStudent")]
        public async Task DeleteStudent(int id)
        {
            await service.DeleteStudent(id);
        }
        [HttpDelete("DeleteWorkTable")]
        public async Task DeleteWorkTable(int id )
        {
            await service.DeleteWorkTable(id);
        }
        #endregion




    }
}
