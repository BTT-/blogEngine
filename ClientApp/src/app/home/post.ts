export interface IPost {
  title: string;
  views: number;
  content: string;
  excerpt: string;
  coverImagePath: string;
  isPublic: boolean;
}

export class Post implements IPost {
  constructor(public title: string,
    public views: number,
    public content: string,
    public excerpt: string,
    public coverImagePath: string,
    public isPublic: boolean) {}
}