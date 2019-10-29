import { Country } from '../Geo/country.model';
import { WorldHeritage } from '../Geo/world-heritage.model';

export interface Stop {
  id: number;
  name: string;
  description: string;
  order: number;
  arrival: Date;
  departure: Date;
  tripId: number;
  latitude: number;
  longitude: number;
  country: Country;
  worldHeritage: WorldHeritage;
}
