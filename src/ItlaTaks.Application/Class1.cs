using ItlaTaks.Infraestructure.Context;
using ItlaTaks.Infraestructure.Interfaces;
using ItlaTaks.Infraestructure.Repositories;

namespace ItlaTaks.Application
{
    public class Class1
    {
        private IProfesorRepository repo = new ProfesorRepository(new TaskContext());

        public async Task Test()
        {
            repo.
        }
    }
}
