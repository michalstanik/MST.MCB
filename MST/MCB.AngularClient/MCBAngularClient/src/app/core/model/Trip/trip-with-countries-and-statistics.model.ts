import { Trip } from './trip.model';
import { Statistics } from './trip-statistics.model';
import { Country } from '../Geo/country.model';
import { Dates } from './trip-dates.model';

export class TripWithCountriesAndStatistics extends Trip {
  statistics: Statistics;
  dates: Dates;
  countries: Country[];
}
