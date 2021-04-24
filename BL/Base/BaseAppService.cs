//using AutoMapper;
//using BL.Configur;
using AutoMapper;
using BL.Base;
using BL.Configur;
using BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Base
{
    public class BaseAppService : IDisposable
    {
        #region Vars
        protected IUnitOfWork TheUnitOfWork { get; set; }
        protected readonly IMapper Mapper = MapperConfig.Mapper;
        #endregion

        #region CTR
        public BaseAppService()
        {
            TheUnitOfWork = new UnitOfWork();
        }

        public void Dispose()
        {
            TheUnitOfWork.Dispose();
        }
        #endregion
    }
}
