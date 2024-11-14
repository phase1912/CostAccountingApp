export class CalculateCostAccountingModel {
  public salePricePerShare: number | undefined;
  public sharesToSell: number | undefined;

  public constructor(
    fields?: {
      salePricePerShare?: string,
      sharesToSell?: string,
    }) {

    if (fields) Object.assign(this, fields);
  }
}
