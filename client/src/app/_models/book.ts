export interface Book {
  id: number;
  title: string;
  author: string;
  publicationYear: number;
  genre: string[];
  description: string;
  coverImage: string;
  liked?: boolean;
  comments?: string[];
}
