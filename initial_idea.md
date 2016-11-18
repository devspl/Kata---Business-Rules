( Simple EventStore inside )

Payment 
-> HandlePayment 
-> PublishPaymentCreated with meta-data - type physical, membership
-> EventConsumers 
  - paymentslip -> if type physical generate paymentslip event
  - book -> generate duplicate payment slip -> roaylyty department
  - activate membership event ->
  - upgrade -> publish upgrade membership event
    - if sucessfull -> send email
  - video special cases
  - commison
