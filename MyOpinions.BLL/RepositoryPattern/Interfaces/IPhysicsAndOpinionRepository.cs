using MyOpinions.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOpinions.BLL.RepositoryPattern.Interfaces
{
	public interface IPhysicsAndOpinionRepository:IRepository<Post>
	{
		List<Post> SelectPhysicsPost();
		List<Post> SelectOpinionPost();
	}
}
