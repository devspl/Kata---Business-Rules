# devspl community - Kata #1

**Kata source**: http://codekata.com/kata/kata16-business-rules/

**Kata author**: Dave Thomas (https://pragdave.me/)

## What is it?

It's a first attempt of DevsPL community located at https://devspl.slack.com/ on sharing different approaches on making architectural coding decisions.
All the 'rules' are based on business requirements stated in predefined code kata, found on webpage mentioned above or in a kata description shared below.
Have fun!

## How-To

To share your approach for sharing your approach for this kata, do the following:
- branch out from `master` branch (naming of the branch is up to you)
- create new folder in root of repository called: `{yourGithubLogin-language-yoursubtitle}`
- *example:* first C# attempt of user 'm-wilczynski' could be `m-wilczynski-csharp-inheritance` and 2nd one could be `mwilczynski-csharp-composition`
- when you're ready to share, start a `pull request` to master branch

## Kata description

### "Business Rules"
How can you tame a wild (and changing) set of business rules?
Imagine you’re writing an order processing application for a large company. In the past, this company used a fairly random mixture of manual and ad-hoc automated business practices to handle orders; they now want to put all these various ways of hanadling orders together into one whole: your application. However, they (and their customers) have come to cherish the diversity of their business rules, and so they tell you that you’ll have to bring all these rules forward into the new system.
When you go in to meet the existing order entry folks, you discover that their business practices border on chaotic: no two product lines have the same set of processing rules. To make it worse, most of the rules aren’t written down: you’re often told something like “oh, Carol on the second floor handles that kind of order.”
During first day of meetings, you’ve decided to focus on payments, and in particular on the processing required when a payment was received by the company. You come home, exhausted, with a legal pad full of rule snippets such as:
- If the payment is for a physical product, generate a packing slip for shipping.
- If the payment is for a book, create a duplicate packing slip for the royalty department.
- If the payment is for a membership, activate that membership.
- If the payment is an upgrade to a membership, apply the upgrade.
- If the payment is for a membership or upgrade, e-mail the owner and inform them of the activation/upgrade.
- If the payment is for the video “Learning to Ski,” add a free “First Aid” video to the packing slip (the result of a court decision in 1997).
- If the payment is for a physical product or a book, generate a commission payment to the agent.

and so on, and so on, for seven long, long, yellow pages.
And each day, to your horror, you gather more and more pages of these rules.
Now you’re faced with implementing this system. The rules are complicated, and fairly arbitrary. What’s more, you know that they’re going to change: once the system goes live, all sorts of special cases will come out of the woodwork.

### Objectives
How can you tame these wild business rules? How can you build a system that will be flexible enough to handle both the complexity and the need for change? And how can you do it without condemming yourself to years and years of mindless support?