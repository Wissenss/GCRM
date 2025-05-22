using GCRM.Domain;
using GCRM.Infraestructure;
using Business;

namespace GCRM.Application
{
	public class CitizenGroupService
	{
		public CitizenGroupService() { }

		public TCitizenGroup GetGroup(int id)
		{
			using (var work = new UnitOfWork())
			{
				TCitizenGroup? group = new CitizenGroupRepository(work).GetById(id);

				if (group == null)
					throw new ServiceException(Error.CitizenGroupNotFound);

				return group;
			}
		}

		public List<TCitizen> GetGroupMembers(int id)
		{
			using (var work = new UnitOfWork())
			{
				return new CitizenGroupRepository(work).GetMembers(id).ToList();
			}
		}

		public TCitizenGroup GetGroupWithMembers(int id)
		{
			using (var work = new UnitOfWork())
			{
				TCitizenGroup? group = new CitizenGroupRepository(work).GetByIdWithMembers(id);

				if (group == null)
					throw new ServiceException(Error.CitizenGroupNotFound);

				return group;
			}
		}

		public List<TCitizenGroup> GetAllGroups()
		{
			using (var work = new UnitOfWork())
			{
				List<TCitizenGroup> all = new List<TCitizenGroup>();

				all = new CitizenGroupRepository(work).GetAll().ToList();

				return all;
			}
		}

		public TCitizenGroup AddGroup(TCitizenGroup group)
		{
			using (var work = new UnitOfWork())
			{
				try
				{
					work.Begin();

					CitizenGroupRepository citizenGroupRepository = new CitizenGroupRepository(work);

					group.Id = citizenGroupRepository.Add(group);

					citizenGroupRepository.AddMembers(group.Id, group.Members);

					work.Commit();
					
					return group;
				}
				catch (Exception)
				{
					work.Rollback();

					throw;
				}
			}
		}

		public TCitizenGroup UpdateGroup(TCitizenGroup group)
		{
			using (var work = new UnitOfWork())
			{
				try
				{
					work.Begin();

					CitizenGroupRepository citizenGroupRepository = new CitizenGroupRepository(work);

					citizenGroupRepository.Update(group);

					citizenGroupRepository.DeleteMembers(group.Id);

					citizenGroupRepository.AddMembers(group.Id, group.Members);

					work.Commit();

					return group;
				}
				catch (Exception)
				{
					work.Rollback();

					throw;
				}
			}
		}

		public void DeleteGroup(int id)
		{
			using (var work = new UnitOfWork())
			{
				try
				{
					work.Begin();

					CitizenGroupRepository citizenGroupRepository = new CitizenGroupRepository(work);

					citizenGroupRepository.Delete(id);
					citizenGroupRepository.DeleteMembers(id);

					work.Commit();
				}
				catch (Exception)
				{
					work.Rollback();

					throw;
				}
			}
		}
	}
}
