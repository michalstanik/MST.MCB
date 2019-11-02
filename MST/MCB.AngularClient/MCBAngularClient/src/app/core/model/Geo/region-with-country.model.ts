import { Country } from './country.model';

export class RegionWithCountryModel {
    id: number;
    countries: Country[];
    visitedCountryCount: number;
    statsCountryCount: number;
  }
