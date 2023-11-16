export class SearchParameters {
  constructor(
    public q?: string,

    public gl?: string,

    public hl?: string,

    public autocorrect?: boolean,

    public page?: number,

    public type?: string

  ) { }
}
