using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MMM.ModelBinders
{
    public class BindModelToViewModel<VM, M> 
        where VM : class 
        where M : class
    {
        private readonly VM _viewModel;
        private readonly M _model;
        public BindModelToViewModel(VM viewModel, M model)
        {
            this._viewModel = viewModel;
            this._model = model;
        }

        public VM BindViewModelByModelWithout(params string[] propertiesNames)
        {
            ICollection<System.Reflection.PropertyInfo> modelProperties = _model.GetType().GetProperties().ToList();
            if (propertiesNames.Length > 0)
            {
                for (int i = 0; i < propertiesNames.Length; i++)
                {
                    foreach (var modelProperty in modelProperties)
                    {
                        if (modelProperty.Name == propertiesNames[i])
                        {
                            modelProperties.Remove(modelProperty);
                            break;
                        }
                    }
                }
            }

            Type typeViewModelName = Type.GetType(_viewModel.GetType().FullName, true);
            object viewModelInstance = Activator.CreateInstance(typeViewModelName);

            foreach (var modelProperty in modelProperties)
            {
                //modelProperty.SetValue(viewModelInstance, modelProperty.GetValue(this), null);
                var propValue = modelProperty.GetValue(_model);
                modelProperty.SetValue(viewModelInstance, propValue);
            }

            return (VM)viewModelInstance;
        }
    }
}