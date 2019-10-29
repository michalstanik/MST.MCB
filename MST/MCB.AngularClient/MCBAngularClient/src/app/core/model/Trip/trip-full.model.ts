import { Country } from '../Geo/country.model';
import { WorldHeritage } from '../Geo/world-heritage.model';
import { Statistics } from './trip-statistics.model';
import { Dates } from './trip-dates.model';
import { User } from 'oidc-client';
import { Stop } from '../Stop/stop-model';

export class TripFull {
  countries: Country[];
  worldHeritages: WorldHeritage[];
  statistics: Statistics;
  dates: Dates;
  users: User[];
  stops: Stop[];
  id: number;
  name: string;
}
