(ns payment.rules.comission)
(use 'payment.rules.utils 'payment.utils)

(defn generate-commision-payment
  "Stub function for generating comission payment."
  [product] (println (str "Generating comission payment for: " product)))

(def comission-payment-rules
  (list (build-action-rule #(product-has-any-type? % (list :physical :book))
                           #(generate-commision-payment %))))