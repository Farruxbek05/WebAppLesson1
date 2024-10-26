using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebAppLesson1.DTO;
using WinFormsApp1.Context;
using WinFormsApp1.Models;
using WinFormsApp1.Repository;

namespace WinFormsApp1.Service
{
	public delegate AppDbContext GetContext();
	public class AppService
	{
		public readonly IGroupRepository _grupRepository;
		public readonly IContractRepository _contractRepository;
		public readonly IStudentRepository _studentRepository;
		public readonly IWorkTableRepository _workTableRepository;
		public readonly ISubjectRepository _subjectRepository;

		public AppService(GroupRepository grupRepository, 
			ContractRepository contractRepository,
			StudentRepository studentRepository,
			WorkTableRepository workTableRepository,
			SubjectRepository subjectRepository)
		{
			_grupRepository = grupRepository;
			_contractRepository = contractRepository;
			_studentRepository = studentRepository;
			_workTableRepository = workTableRepository;
			_subjectRepository = subjectRepository;
		}
		
		#region Group
		public async  Task<Group>   AddGroup(Group grop)
		{
		return	await _grupRepository.CreateAsync(grop);
		}
		
		public async Task<IEnumerable<Group>> GetAllGroup(Expression<Func<Group, bool>> expression = null)		
		{
			return await _grupRepository.GetAll(expression);
		}
		public async Task<Group> UpdateGroup(Group group)
		{
			return await _grupRepository.UpdateAsync(group);
		}
		public async Task DeleteGroup(int id )
		{
			var re= await _grupRepository.GetAll(x=>x.Id==id);
			var group= re.FirstOrDefault();
	       await _grupRepository.DeleteAsync(group);
		}
		public async Task<Group> CreateGroup(string name)
		{
			Group group = new Group();
			group.Name = name;

			return await _grupRepository.CreateAsync(group);
		}
            #endregion
        #region Contract
        public async Task<IEnumerable<Contract>> GetAllContract(Expression<Func<Contract, bool>> expression = null)
		{
			return await _contractRepository.GetAll(expression);
		}
		public async Task DeleteContract(int id)
		{
			var re= await _contractRepository.GetAll(x=> x.Id==id);
			var contract= re.FirstOrDefault();
			await _contractRepository.DeleteAsync(contract);
		}
		public async Task<Contract> CreateContract(string name)
		{
			Contract contract = new Contract()
			{
				Name = name,
			};
		
			return await _contractRepository.CreateAsync(contract);
		}
		public async Task<Contract>UpdateContract(Contract contract)
		{
			return await _contractRepository.UpdateAsync(contract);
		}
		
		


		#endregion
		#region Subject
		public async Task<IEnumerable<Subject>> GetAllSubject(Expression<Func<Subject, bool>> expression = null)
		{
			return await _subjectRepository.GetAll(expression);
		}
		public async Task<Subject>CreateSubject(string name)
		{
			Subject subject=new Subject();
			subject.Name=name;
			return await  _subjectRepository.CreateAsync(subject);
		}
		public async Task<Subject>Updatesubject(Subject subject)
		{
			return await _subjectRepository.UpdateAsync(subject);
		}
		public async Task Deletesubject(int id)
		{
			var res=await _subjectRepository.GetAll(x=>x.Id==id);
			var subject = res.FirstOrDefault();
			 await _subjectRepository.DeleteAsync(subject);
		}

		#endregion
		#region Student
		public async Task<IEnumerable<Student>> GetAllStudent(Expression<Func<Student, bool>> expression = null)
		{
			return await _studentRepository.GetAll(expression);
		}
		public async Task<Student> UpdateStudent(int id,StudentDto student)
		{
			var res = await _studentRepository.GetAll(x=>x.ID==id);
			var students=res.FirstOrDefault();
			students.Name=student.Name;
			students.ContractId=student.contractId;
			students.GroupId=student.groupId;
			return  await _studentRepository.UpdateAsync(students);
		}
		public async Task<Student> CreateStudent(StudentDto studentDto)
		{
			Student student = new Student();

			student.Name = studentDto.Name;
			student.ContractId = studentDto.contractId;
			student.GroupId = studentDto.groupId;
		
		  return 	await _studentRepository.CreateAsync(student);
		}
		public async Task DeleteStudent(int id)
		{
			var res=await _studentRepository.GetAll(x=> x.ID==id);
			var students=res.FirstOrDefault();
			await _studentRepository.DeleteAsync(students);
		}
		#endregion
		#region WorkTable
		public async Task<WorkTable> AddWorkTable(WorkTableDto workTableDto)
		{
			WorkTable workTable = new WorkTable();
			workTable.SubjectId = workTableDto.SubjectId;
			workTable.GroupId=workTableDto.GroupId;
			return await _workTableRepository.CreateAsync(workTable);
		}

		public async Task<IEnumerable<WorkTable>> GetAllWorkTable(Expression<Func<WorkTable, bool>> expression = null)
		{
			return await _workTableRepository.GetAll(expression);
		}
		public async Task<WorkTable> UpdateWorkTable(int id,WorkTableDto workTable)
		{
			var res=await _workTableRepository.GetAll(x=>x.Id==id);
			var worktables = res.FirstOrDefault();
			worktables.SubjectId= workTable.SubjectId;
			worktables.GroupId= workTable.GroupId;

		 return	await _workTableRepository.UpdateAsync(worktables);
		}
		public async Task DeleteWorkTable(int id)
		{
			var res=await _workTableRepository.GetAll(x=> x.Id==id);
			var worktables = res.FirstOrDefault();
			await _workTableRepository.DeleteAsync(worktables);
		}
		#endregion
	}
}
