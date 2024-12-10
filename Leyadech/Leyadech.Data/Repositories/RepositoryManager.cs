using Leyadech.Core.Entities;
using Leyadech.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leyadech.Data.Repositories
{
    public class RepositoryManager: IRepositoryManager
    {
        private readonly DataContext _context;
        public IMotherRepository Mothers { get; }
        public IVolunteerRepository Volunteers { get; }
        public IRequestRepository Requests { get; }
        public ISuggestRepository Suggests { get; }
        public IVolunteeringRepository Volunteerings { get; }


        public RepositoryManager(DataContext context, IMotherRepository motherRepository,
            IVolunteerRepository volunteerRepository,IRequestRepository requestRepository,
            ISuggestRepository suggestRepository,IVolunteeringRepository volunteeringRepository)
        {
            _context = context;
            Mothers= motherRepository;
            Volunteers= volunteerRepository;
            Requests= requestRepository;
            Suggests= suggestRepository;
            Volunteerings= volunteeringRepository;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
