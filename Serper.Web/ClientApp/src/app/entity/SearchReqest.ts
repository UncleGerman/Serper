export class SearchReqest {
    constructor(
        public id?: number,

        public position?: number,
        
        public query?: string,
    
        public descriptionLink?: string
    ){}
}