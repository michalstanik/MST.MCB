import { Country } from './country.model';
import { RegionModel } from './region.model';

export class RegionWithCountryModel extends RegionModel {
    countries: Country[];
    visitedCountryCount: number;
    countriesCount: number;
  }
