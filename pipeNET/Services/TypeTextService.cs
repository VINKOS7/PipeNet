using System;
using System.Text.RegularExpressions;
using SpeechNet.Controllers;
using Microsoft.Extensions.Logging;

namespace SpeechNet.Services
{

	public class TypeTextService
    {
		static string TXT = "";
		static double mid_leght_SENTENCE = 0;

		// доля частей речи нач
		static double particle_share = 0;
		static double adjective_share = 0;
		static double pronoun_share = 0;
		static double adverb_share = 0;
		static double verb_share = 0;
		static double noun_share = 0;
		static double gerunds_share = 0;
		static double Participle_share = 0;
		// доля комбинации частей речи кон

		// количество частей речи нач
		static double particle_quantity = 0;
		static double adjective_quantity = 0;
		static double pronoun_quantity = 0;
		static double adverb_quantity = 0;
		static double verb_quantity = 0;
		static double noun_quantity = 0;
		static double gerunds_quantity = 0;
		static double participle_quantity = 0;
		// количество частей речи кон

		// количество комбинации частей речи нач
		static double gerunds_noun_quantity = 0;
		static double gerunds_adverb_quantity = 0;
		static double verb_noun_quantity = 0;
		static double verb_adverb_quantity = 0;
		static double noun_noun_quantity = 0;
		static double adjective_noun_quantity = 0;
		// количество комбинации частей речи кон

		static double combinations = 0.0;

		static double quantityLETTERS = 0;
		static double quantitySENTENCE = 0;
		static double quantityWORDS = 0;

		static void CleanProerties()
        {
			particle_share = 0;
			adjective_share = 0;
			pronoun_share = 0;
			adverb_share = 0;
			verb_share = 0;
			noun_share = 0;
			gerunds_share = 0;
			Participle_share = 0;
			// доля комбинации частей речи кон

			// количество частей речи нач
			particle_quantity = 0;
			adjective_quantity = 0;
			pronoun_quantity = 0;
			adverb_quantity = 0;
			verb_quantity = 0;
			noun_quantity = 0;
			gerunds_quantity = 0;
			participle_quantity = 0;
			// количество частей речи кон

			// количество комбинации частей речи нач
			gerunds_noun_quantity = 0;
			gerunds_adverb_quantity = 0;
			verb_noun_quantity = 0;
			verb_adverb_quantity = 0;
			noun_noun_quantity = 0;
			adjective_noun_quantity = 0;
			// количество комбинации частей речи кон

			combinations = 0;

			quantityLETTERS = 0;
			quantitySENTENCE = 0;
			quantityWORDS = 0;
		}

		static bool IsLet(char let) 
		{
			Regex RegexLetters = new Regex(@"[А-Я]|[а-я]|[ё]|[Ё]$");
			if (RegexLetters.IsMatch(Convert.ToString(let)))
			{
				return true;
			}

			return false;
		}

		static bool IsEndSentenсe(string letters, string type, int index)// доделать все случаи
        {
			if (letters != null)
			{
				Regex RegexLetters = new Regex(@"(([А-Я]{1,}[а-я]{1,})|([а-я]{1,}))[\.]$");

				if (RegexLetters.IsMatch(letters))
				{
					if (type != "сущ") return true;
                    else
                    {
						RegexLetters = new Regex(@"[А-Я][\.]$");

						if (RegexLetters.IsMatch(letters))
                        {
							RegexLetters = new Regex(@"[А-Я]");

							if (RegexLetters.IsMatch(TXT[index + 2].ToString())) return false;
							else return true;
                        }
					}
				}
			}

			return false;
		}

		static string CountingTypeWords(string TypeWord, string last) 
		{
			if (TypeWord == "частица") particle_quantity++;
			else if (TypeWord == "прилагательное") adjective_quantity++;
			else if (TypeWord == "наречие") adverb_quantity++;
			else if (TypeWord == "глагол") verb_quantity++;
			else if (TypeWord == "причастие") participle_quantity++;
			else if (TypeWord == "деепричастие") gerunds_quantity++;
			else if (TypeWord == "местоимение") pronoun_quantity++;
			else noun_quantity++;

			if (last != "") 
			{
                if (last == "деепричастие") 
				{
					if (TypeWord == "существительное") gerunds_noun_quantity++;
					if (TypeWord == "наречие") gerunds_adverb_quantity++;
				}
				else if (last == "глагол")
				{
					if (TypeWord == "существительное") verb_noun_quantity++;
					if (TypeWord == "наречие") verb_adverb_quantity++;
				}
				else if (last == "существительное")
				{
					if (TypeWord == "существительное") noun_noun_quantity++;
				}
				else if (last == "прилагательное")
				{
					if (TypeWord == "существительное") adjective_noun_quantity++;
				}
			}

				return TypeWord;
		}


		static public string TypeText(string txt)
		{
			HomeController StyleWord = new(null,null,null);

			TXT = txt;

			txt = null;

			string typeTXT = "", BufWord = "", Buf_TypeWord_Last = "", Buf_TypeWord = "";

            for (int i = 0; i < TXT.Length; i++) 
			{	

				if (IsLet(TXT[i]) == true)
				{
					BufWord += TXT[i];

					quantityLETTERS++;
				}
				else if(BufWord != null)
				{
					if (Buf_TypeWord != "") Buf_TypeWord_Last = Buf_TypeWord;

					Buf_TypeWord = StyleWord.InsidewordTYPE(BufWord);

					if (Buf_TypeWord == "ошибка") return "ошибка в методе TWS";

					CountingTypeWords(Buf_TypeWord, Buf_TypeWord_Last);

					if (TXT[i] == '.')
					{
						BufWord += '.';

						if (IsEndSentenсe(BufWord, Buf_TypeWord, i) == true) quantitySENTENCE++;
					}
					else if (TXT[i] == '!') quantitySENTENCE++;
					else if (TXT[i] == '?') quantitySENTENCE++;

					quantityWORDS++;

					BufWord = null;
				}
			}

			//Counting() та функция из с++ версии
			if ((noun_noun_quantity + adjective_noun_quantity) != 0)
				combinations = (verb_noun_quantity + verb_adverb_quantity + gerunds_noun_quantity + gerunds_adverb_quantity) / (noun_noun_quantity + adjective_noun_quantity);

			mid_leght_SENTENCE =  quantityWORDS / quantitySENTENCE;
			pronoun_share = pronoun_quantity / quantityWORDS;
			adjective_share = adjective_quantity / quantityWORDS;
			particle_share = particle_quantity / quantityWORDS;
			//

			//string style() та функция из с++ версии
			if (combinations <= 0.1) typeTXT = "Деловой"; // mid_leght_SENTENCE >= 18 && это условие убрано, так он отделяет пуб. стиль от дел., но это работает с большими текстами.
			else if (particle_share >= 0.02 && pronoun_share >= 0.03) typeTXT = "Художественный";
			else if (particle_share <= 0.025 && combinations <= 0.32 && adjective_share >= 0.1 && adjective_share <= 0.2) typeTXT = "Научный";
			else typeTXT = "Публицистический";
			//

			CleanProerties();

			return typeTXT;
        }
    }
}
