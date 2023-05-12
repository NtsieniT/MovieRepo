using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IMovieRepository MovieRepository { get; }
        ITypeRepository TypeRepository { get; }


        Task<bool> Complete();
    }
}
