import { RegionModel } from './region.model';
import { CountryWithAssessment } from './country-with-assessment.model';

export class RegionWithCountriesAndAssessment extends RegionModel {
  countries: CountryWithAssessment[];
}
