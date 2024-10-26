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
	public interface IAppServise
	{
		
#pragma warning disable CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
		Task<IEnumerable<Group>> GetAllGroup(Expression<Func<Group, bool>> expression = null);
#pragma warning restore CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
		Task DeleteGroup(int id);
		Task<Group> CreateGroup(string name);

        Task<Group> UpdateGroup(Group add);
#pragma warning disable CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
		Task<IEnumerable<Contract>> GetAllContract(Expression<Func<Contract, bool>> expression = null);
#pragma warning restore CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
		Task DeleteContract(int id);
		Task<Contract> CreateContract(string name);
		Task<Contract> UpdateContract(Contract contract);
#pragma warning disable CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
		Task<IEnumerable<Subject>> GetAllSubject(Expression<Func<Subject, bool>> expression = null);
#pragma warning restore CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
		Task DeleteSubject(int id);
		Task<Subject> CreateSubject(string name);
		Task<Subject> Updatesubject(Subject subject);
#pragma warning disable CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
		Task<IEnumerable<Student>> GetAllStudent(Expression<Func<Student, bool>> expression = null);
#pragma warning restore CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
		Task DeleteStudent(int id);
		Task<Student> CreateStudent(StudentDto studentDto);
		Task<Student> UpdateStudent(int id, StudentDto student);
		Task<WorkTable> AddWorkTable(WorkTableDto workTableDto);
#pragma warning disable CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
		Task<IEnumerable<WorkTable>> GetAllWorkTable(Expression<Func<WorkTable, bool>> expression = null);
#pragma warning restore CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
		Task DeleteWorkTable(int id);
		Task<WorkTable> UpdateWorkTable(int id, WorkTableDto workTable);
    }


	public class AppService:IAppServise
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
#pragma warning disable CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
		public async Task<IEnumerable<Group>> GetAllGroup(Expression<Func<Group, bool>> expression = null)		
#pragma warning restore CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
		{
			return await _grupRepository.GetAll(expression);
		}
		public async Task<Group> UpdateGroup(Group add)
		{
            var re = await _grupRepository.GetAll(x => x.Id ==add.Id);
            var group = re.FirstOrDefault();
			if(group != null)
			{
				group.Name = add.Name;
				await _grupRepository.UpdateAsync(group);

			}

#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
            return await _grupRepository.UpdateAsync(group);
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
		}
		public async Task DeleteGroup(int id )
		{
			var re= await _grupRepository.GetAll(x=>x.Id==id);
			var group= re.FirstOrDefault();
#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
	       await _grupRepository.DeleteAsync(group);
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
		}
		public async Task<Group> CreateGroup(string name)
		{
			Group group = new Group();
			group.Name = name;

			return await _grupRepository.CreateAsync(group);
		}
            #endregion
        #region Contract
#pragma warning disable CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
        public async Task<IEnumerable<Contract>> GetAllContract(Expression<Func<Contract, bool>> expression = null)
#pragma warning restore CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
		{
			return await _contractRepository.GetAll(expression);
		}
		public async Task DeleteContract(int id)
		{
			var re= await _contractRepository.GetAll(x=> x.Id==id);
			var contract= re.FirstOrDefault();
#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
			await _contractRepository.DeleteAsync(contract);
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
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
            var re = await _contractRepository.GetAll(x => x.Id == contract.Id);
            var contracts = re.FirstOrDefault();
			if(contracts != null)
			{
				contracts.Name = contract.Name;
				await _contractRepository.UpdateAsync(contract);
			}

            return await _contractRepository.UpdateAsync(contract);
		}
		
		


		#endregion
		#region Subject
#pragma warning disable CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
		public async Task<IEnumerable<Subject>> GetAllSubject(Expression<Func<Subject, bool>> expression = null)
#pragma warning restore CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
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
            var res = await _subjectRepository.GetAll(x => x.Id == subject.Id);
            var subjects = res.FirstOrDefault();
			if(subjects != null)
			{
				subjects.Name = subject.Name;
				await _subjectRepository.UpdateAsync(subjects);
			}
            return await _subjectRepository.UpdateAsync(subject);
		}
		public async Task DeleteSubject(int id)
		{
			var res=await _subjectRepository.GetAll(x=>x.Id==id);
			var subject = res.FirstOrDefault();
#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
			 await _subjectRepository.DeleteAsync(subject);
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
		}

		#endregion
		#region Student
#pragma warning disable CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
		public async Task<IEnumerable<Student>> GetAllStudent(Expression<Func<Student, bool>> expression = null)
#pragma warning restore CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
		{
			return await _studentRepository.GetAll(expression);
		}
		public async Task<Student> UpdateStudent(int id,StudentDto student)
		{
			var res = await _studentRepository.GetAll(x=>x.ID==id);
			var students=res.FirstOrDefault();
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
			students.Name=student.Name;
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
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
#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
			await _studentRepository.DeleteAsync(students);
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
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

#pragma warning disable CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
		public async Task<IEnumerable<WorkTable>> GetAllWorkTable(Expression<Func<WorkTable, bool>> expression = null)
#pragma warning restore CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
		{
			return await _workTableRepository.GetAll(expression);
		}
		public async Task<WorkTable> UpdateWorkTable(int id,WorkTableDto workTable)
		{
			var res=await _workTableRepository.GetAll(x=>x.Id==id);
			var worktables = res.FirstOrDefault();
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
			worktables.SubjectId= workTable.SubjectId;
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
			worktables.GroupId= workTable.GroupId;

		 return	await _workTableRepository.UpdateAsync(worktables);
		}
		public async Task DeleteWorkTable(int id)
		{
			var res=await _workTableRepository.GetAll(x=> x.Id==id);
			var worktables = res.FirstOrDefault();
#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
			await _workTableRepository.DeleteAsync(worktables);
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
		}
		#endregion
	}
}
