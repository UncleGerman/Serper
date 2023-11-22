import { KnowledGegraph } from "./KnowledGegraph";
import { Organic } from "./Organic";

export class RootObject {
  constructor(
    public knowledgeGraph?: KnowledGegraph,

    public organic?: Array<Organic>,

  ) { }
}
