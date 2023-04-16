export interface IGameType {
  id: number;
  description: string;
}

export class GameType implements IGameType {
  id!: number;
  description!: string;

}
