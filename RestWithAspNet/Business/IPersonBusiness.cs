﻿using RestWithAspNet.Data.VO;
using RestWithAspNet.Model;
using System.Collections.Generic;

namespace RestWithAspNet.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindById(long id);
        PersonVO Update(PersonVO person);
        void Delete(long id);
        List<PersonVO> FindAll();
        PersonVO Disable(long id);
    }
}
