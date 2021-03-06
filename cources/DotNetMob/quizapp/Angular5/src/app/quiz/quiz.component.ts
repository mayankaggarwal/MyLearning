import { QuizService } from './../shared/quiz.service';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-quiz',
  templateUrl: './quiz.component.html',
  styleUrls: ['./quiz.component.css']
})
export class QuizComponent implements OnInit {

  constructor(private router:Router,private quizService:QuizService) { }

  ngOnInit() {
    this.quizService.seconds = 0;
    this.quizService.qnProgress = 0;
    this.quizService.getQuestions()
      .subscribe((data:any)=>{
        this.quizService.qns = data;
        this.startTimer();
      });
  }

  startTimer(){
    this.quizService.timer = setInterval(()=>{
      this.quizService.seconds++;
    },1000);
  }

  Answer(qID,choice){
    this.quizService.qns[this.quizService.qnProgress].answer = choice;
    this.quizService.qnProgress++;
    if(this.quizService.qnProgress==10){
      clearInterval(this.quizService.timer);
      this.router.navigate(['/result']);
    }
  }

}
