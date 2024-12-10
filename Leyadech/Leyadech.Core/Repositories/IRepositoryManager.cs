using Leyadech.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leyadech.Core.Repositories
{
    public interface IRepositoryManager
    {
        public IMotherRepository Mothers { get; }
        public IVolunteerRepository Volunteers { get; }
        public IRequestRepository Requests { get; }
        public ISuggestRepository Suggests { get; }
        public IVolunteeringRepository Volunteerings { get; }

        void Save();
    }
}
