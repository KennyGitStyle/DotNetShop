import { IProduct } from "./product";

export interface IPaginate {
  pageIndex: number;
  pageSize: number;
  count: number;
  data: IProduct[];
}

