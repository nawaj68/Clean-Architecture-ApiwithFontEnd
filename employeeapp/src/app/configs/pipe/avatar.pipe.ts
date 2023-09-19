
import {Pipe, PipeTransform} from "@angular/core";
import { environment } from "src/enviroments/enviroment";
@Pipe({name: "avatar"})
export class AvatarPipe implements PipeTransform {
  transform(value: string, alt: string = ""): string {
    const url = `${environment.baseUrl}/${value}`;
    return `<img width="50" class="img-thumbnail" src=${url} alt=${alt} />`;
  }
}
