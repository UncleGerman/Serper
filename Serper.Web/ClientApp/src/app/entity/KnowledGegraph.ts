import { Attributes } from "./Attributes";

export class KnowledGegraph {
  constructor(
    public title?: string,

    public type?: string,

    public website?: string,

    public imageUrl?: string,

    public description?: string,

    public descriptionSource?: string,

    public descriptionLink?: string,

    public attributes?: Attributes

  ) { }
}
