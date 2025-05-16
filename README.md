# Eedi API Task
The goal of this task is to review an existing feature and spec out the data structures and API endpoints that will allow a third party company to implement it on their own site. It should take about 30 - 45mins.

## Improve
A tutoring agency would like to integrate our feature that allows students to independently review and re-answer questions that they have previously answered incorrectly. This is useful for a student who has completed their assigned in class work quickly and needs extra work to do.

A student should be able to view the topics where they have incorrect answers, select a topic, view questions again, and update their previous answer.

This section is called “Improve”.

In Figma you'll see the design and flow: [figma design](https://www.figma.com/design/cBhoA2SdIGTQgDpm2jj9cu/Improve?node-id=0-1&p=f).

### List page
This section lists topics and sub-topics where the current student has misconceptions.

- It should list sub-topics grouped by their parent topic.
- Each sub-topic will have a number of misconceptions (previously answered questions that the student got wrong).
- Sub-topics with no misconceptions will not be shown in this list.

### View page
When a student clicks "View Questions" for a particular sub-topic they will be taken to a single question page where they can view one question that they answered incorrectly and re-answer.

- All questions are images.
- All questions can only be answered A, B, C or D and one answer is correct.
- Each answer also has an explanation that can be shown to the student.

## What you need to do
Based on the design and requirements, you will need to:

- Design the API endpoints that will provide the functionality for the Improve section. You don’t need to write any code for the endpoints themselves, just examples of the URLs.
- Show example requests & responses for these endpoints.
- Include any notes based on the assumptions you've made.
- Don’t worry about authentication, assume that’s all been taken care of

## Prerequisites
To setup the Eedi API the following software is required:

- Visual Studio 2022 (Community or higher) or Visual Studio Code.
- .NET Core 9.0 SDK
- (Optional) In Visual Studio, you might like the Markdown Editor extension to get a Markdown preview for this file.

## Installation
Clone from Git 

1. In Team Explorer, go to Manage Connections then open the Connect view.
2. Select Clone under Local Git Repositories and enter the URL for your Git repo

```bash
https://github.com/VUDevEnv/Eedi.git
```

3. Select a folder where you want your cloned repo to be kept.
4. Select Clone to clone the repo.

## Notes
[**Swagger URL**](https://localhost:44303/swagger/index.html)

