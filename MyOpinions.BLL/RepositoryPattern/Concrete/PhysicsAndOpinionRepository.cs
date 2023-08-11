using MyOpinions.BLL.RepositoryPattern.Base;
using MyOpinions.BLL.RepositoryPattern.Interfaces;
using MyOpinions.DAL.Context;
using MyOpinions.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOpinions.BLL.RepositoryPattern.Concrete
{
	public class PhysicsAndOpinionRepository : Repository<Post>, IPhysicsAndOpinionRepository
	{
		public PhysicsAndOpinionRepository(MyDbContext db) : base(db)
		{
		}

		public List<Post> SelectOpinionPost()
		{
			return table.Where(x => x.CategoryID == 2 && x.Status != MODEL.Enums.DataStatus.Deleted).ToList();
		}

		public List<Post> SelectPhysicsPost()
		{
			return table.Where(x => x.CategoryID == 1 && x.Status != MODEL.Enums.DataStatus.Deleted).ToList();
		}
	}
}
