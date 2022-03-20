export class Post {
    constructor(
        public id: number,
        public title: string,
        public author: string,
        public publisheddate: string,
        public excert: string,
        public image?: string
    ) { }
}