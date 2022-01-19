using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeechNet.Services
{
    public class GetPriorityRole
    {
        public static int GetP(string name)
        {
            int priotity = 0;

            List<string> roles = new List<string>();

            roles.Add("adminGLOBAL");
            roles.Add("adminGENERAL");
            roles.Add("admin");
            roles.Add("moder");
            roles.Add("ban");
            roles.Add("def");

            for (int i = 0; i < roles.Count(); i++)
            {
                if (roles[i] == name)
                {
                    priotity = i;
                    break;
                }
            }

            return priotity;
        }

        public static bool GetP(string name, string second_name = null, string tripple_name = null)
        {
            bool priotity = false;

            List<string> roles = new List<string>();

            roles.Add("adminGLOBAL");
            roles.Add("adminGENERAL");
            roles.Add("admin");
            roles.Add("moder");
            roles.Add("def");

            if (second_name == null)
            {
                for (int i = 0; i < roles.Count() - 1; i++)
                {
                    if (roles[i] ==  name)
                    {
                        priotity = true;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < roles.Count(); i++)
                {
                    if (name == second_name) return false;

                    if (roles[i] == name)
                    {
                        for(int j = 0; j < roles.Count(); j++)
                        {
                            if(roles[j] == tripple_name)
                            {
                                if (i - 1 < j) return false;
                                else return true;
                            }
                        }
                    }
                }
                for (int i = 0; i < roles.Count(); i++)
                {

                    if (roles[i] == name)
                    {
                        if (name == tripple_name) break;
                        if (name == second_name) break;

                        priotity = true;
                        break;
                    }
                    else if (roles[i] == second_name) break;
                }
            }

            return priotity;
        }
    }
}
