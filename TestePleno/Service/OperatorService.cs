﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePleno.Models;

namespace TestePleno
{
    public class OperatorService
    {
        public Repository _repository = new Repository();
        
        public Repository getRepo()
        {
            return _repository;
        }

        public Operator GetOperatorByCode(string code)
        {
            var operators = _repository.GetAll<Operator>();
            var selectedOperator = operators.FirstOrDefault(o => o.Code == code);
            return selectedOperator;
        }

        public Operator GetOperatorById(string id)
        {
            var selectedOperator = _repository.GetById<Operator>(id);
            return selectedOperator;
        }

        public List<Operator> GetOperators()
        {
            var operators = _repository.GetAll<Operator>();
            return operators;
        }

        public void Create(Operator insertingOperator)
        {
            if(_repository.Existe(insertingOperator.Code))
            {               
            }
            else
            {
                _repository.Insert(insertingOperator);
            }
            
        }

        public void Update(Operator updatingOperator)
        {
            _repository.Update(updatingOperator);
        }
    }
}
