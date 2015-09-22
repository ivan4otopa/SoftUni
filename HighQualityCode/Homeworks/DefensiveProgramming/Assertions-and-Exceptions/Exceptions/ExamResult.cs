﻿using System;

public class ExamResult
{
    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentOutOfRangeException("Grade can't be negative.");
        }

        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException("Minimum grade can't be negative.");
        }

        if (maxGrade <= minGrade)
        {
            throw new ArgumentOutOfRangeException("Maximum grade can't be less than or equal to minimum grade.");
        }

        if (string.IsNullOrEmpty(comments))
        {
            throw new ArgumentNullException("Comments can't be null or empty.");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade { get; private set; }

    public int MinGrade { get; private set; }

    public int MaxGrade { get; private set; }

    public string Comments { get; private set; }
}
