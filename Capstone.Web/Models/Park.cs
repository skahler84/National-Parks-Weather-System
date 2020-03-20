using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
	public class Park
	{
	public string parkCode {get; set;}
	public string parkName {get; set;}
	public string state { get; set;}
	public int acreage { get; set;}
	public int elevationInFeet { get; set;}
	public double milesOfTrail { get; set; }
	public int numberOfCampsites { get; set;}
	public string climate { get; set;}
	public int yearFounded { get; set;}
	public int annualVisitorCount { get; set;}
	public string inspirationalQuote { get; set;}
	public string inspirationalQuoteSource { get; set;}
	public string parkDescription {get; set;}
	public int entryFee{ get; set;}
	public int numberOfAnimalSpecies { get; set; }

	//double fahrenheit;
	//double celsius = 36;
    //fahrenheit = (celsius* 9) / 5 + 32;



	}
}
