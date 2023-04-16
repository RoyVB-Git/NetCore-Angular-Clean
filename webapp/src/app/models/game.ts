import { IGameType, GameType } from './gameType';

export interface IGame {
  id: number;
  name: string;
  description: string;
  gameTypeId: number;
  gameType: IGameType;
}

export class Game implements IGame {
  id!: number;
  name!: string;
  description!: string;
  gameTypeId!: number;
  gameType!: GameType;
}
