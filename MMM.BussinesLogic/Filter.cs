using System;
using System.Reflection;

namespace MMM.BussinesLogic
{
    public class Filter<T> where T : class 
    {
        public string GetPropertyName(string filterName)
        {
            string propertyName = "";

            CheckIfThereIsPropertyNameInClass(filterName, out propertyName);

            return propertyName;
        }

        public string EncodeAmountFilter(string filtername)
        {
            return filtername.Remove(0,1);
        }

        public bool CheckIfFilterIsAmount(string filtername)
        {
            return filtername.ToLower().Contains("amount") ? true : false;
        }

        public bool CheckIfAmountIsNegative(string filtername)
        {
            return filtername.ToLower().Contains("-") ? true : false;
        }

        public bool CheckIfAmountIsPositive(string filtername)
        {
            return filtername.ToLower().Contains("+") ? true : false;
        }

        private void CheckIfThereIsPropertyNameInClass(string filterName, out string propertyName)
        {
            propertyName = "";
            Type myType = typeof(T);
            PropertyInfo[] listPropsInfo = myType.GetProperties();

            foreach (var propInfo in listPropsInfo)
            {
                if (String.Compare(propInfo.Name, filterName, true) == 0)
                {
                    propertyName = propInfo.Name;
                    break;
                }
            }
        }
    }
}