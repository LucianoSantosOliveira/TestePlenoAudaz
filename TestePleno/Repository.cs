using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePleno.Models;

namespace TestePleno
{
    public class Repository
    {
        private List<IModel> _fakeDatabase = new List<IModel>();

        public void Insert(IModel model)
        {
            if (model.Code == "")
                throw new Exception("Não é possível salver um registro com Id não preenchido");

            //var modelAlreadyExists = _fakeDatabase.Any(savedModel => savedModel.Id == model.Id);
            //if (modelAlreadyExists)
            //    throw new Exception($"Já existe um registro para a entidade '{model.GetType().Name}' com o Id '{model.Code}'");


            _fakeDatabase.Add(model);
        }

        public void Update(IModel model)
        {
            var updatingModel = _fakeDatabase.FirstOrDefault(savedModel => savedModel.Id == model.Id);
            if (updatingModel == null)
                throw new Exception($"Não há registros para a entidade '{model.GetType().Name}' com Id '{model.Code}'");

            _fakeDatabase.Remove(updatingModel);
            _fakeDatabase.Add(model);
        }

        public T GetById<T>(string code)
        {
            var model = _fakeDatabase.FirstOrDefault(savedModel => savedModel.Id == code);
            return (T)model;
        }

        public List<T> GetAll<T>()
        {
            var allModels = _fakeDatabase.Where(savedModel => savedModel.GetType().IsAssignableFrom(typeof(T)));
            var convertedModels = allModels.Select(genericModel => (T)genericModel).ToList();
            return convertedModels;
        }
    }
}
