export class CalculateCostAccountingModel {
  public companyName: string | undefined;
  public salePricePerShare: number | undefined;
  public sharesToSell: number | undefined;

  public constructor(
    fields?: {
      companyName?: string,
      salePricePerShare?: string,
      sharesToSell?: string,
    }) {

    if (fields) Object.assign(this, fields);
  }
}
