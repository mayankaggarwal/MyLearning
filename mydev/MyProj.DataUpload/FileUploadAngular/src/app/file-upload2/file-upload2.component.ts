import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpRequest, HttpEventType, HttpResponse } from '@angular/common/http'
const API_URL2 = "http://localhost:5000/api/FileUpload";
@Component({
  selector: 'app-file-upload2',
  templateUrl: './file-upload2.component.html',
  styleUrls: ['./file-upload2.component.css']
})
export class FileUpload2Component implements OnInit {
  public progress: number;
  public message: string;
  constructor(private http: HttpClient) { }

  ngOnInit() {
  }
  upload(files) {
    if (files.length === 0)
      return;

    const formData = new FormData();

    for (let file of files)
      formData.append(file.name, file);

    const uploadReq = new HttpRequest('POST', API_URL2, formData, {
      reportProgress: true,
    });

    this.http.request(uploadReq).subscribe(event => {
      if (event.type === HttpEventType.UploadProgress)
        this.progress = Math.round(100 * event.loaded / event.total);
      else if (event.type === HttpEventType.Response)
        this.message = "Response";
    });
  }
}
