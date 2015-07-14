using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomaciRad2Testiranje
{
    public class Date
    {
        private string[] mjeseciUGodini = {"Sijecanj","Veljaca","Ozujak","Travanj","Svibanj","Lipanj","Srpanj","Kolovoz","Rujan","Listopad","Studeni","Prosinac"} ;
        private int godina, mjesec, dan;

        public Date(int godina, int mjesec, int dan)
        {
            if (godina!=0 && mjesec < 13 && mjesec > 0 && dan < 32 && dan > 0)
            {
                this.godina = godina;
                this.mjesec = mjesec;
                this.dan = dan;
            }
            else
            {
                throw new InvalidProgramException("Krivi unos vrijednosti za mjesec i/ili dan"); 
            }
        }

        public string getMonthName(Date datum)
        {
            return mjeseciUGodini[datum.mjesec - 1];
        }

        public int getNumberOfRemainingDaysInMonth(Date datum)
        {
            switch (datum.mjesec)
            {
                case 1: 
                case 3: 
                case 5: 
                case 7: 
                case 8: 
                case 10:
                case 12:
                        return 31 - datum.dan; //uvijek ce biti manji ili jednak 31 za to se brine konstruktor
                case 4: 
                case 6: 
                case 9:
                case 11: 
                    if(datum.dan != 31) // ne smije biti jednak 31, a da je manji tj da nije veci je briga konstruktora
                        return 30 - datum.dan;
                    else
                        throw new InvalidProgramException("Dan ne smije biti veći od 30");
                case 2:
                    if (isLeapYear(datum.godina) && datum.dan < 30)
                        return 29 - datum.dan;
                    else if (!isLeapYear(datum.godina) && datum.dan < 29)
                        return 28 - datum.dan;
                    else
                        throw new InvalidProgramException("Kriv unos dana za mjesec Veljaču");
                default:
                    throw new InvalidProgramException("Krivi unos mjeseca"); 

            }
            
        }

        private bool isLeapYear(int godina)
        {
            if (godina%4==0 && (godina%100!=0 || godina%400==0)) 
                return true;
            else
                return false;
        }
    }
}
