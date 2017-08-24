using System.Linq;

namespace MMM.BussinesLogic
{
    public class ClaimsLogic
    {
        public void SeparateNameToFirstNameAndLastName(ref string name, out string firstName, out string lastName)
        {
            var splitedName = name.Split(' ');
            firstName = splitedName[0];
            lastName = "";
            if (splitedName.Length > 1)
            {
                lastName = splitedName[1];
            }
        }
    }
}