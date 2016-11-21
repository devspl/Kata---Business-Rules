(ns payment.core)
(use 'payment.rules.utils)

(def payment-rules
  (concat payment.rules.membership/membership-payment-rules
          payment.rules.packaging/packaging-payment-rules
          payment.rules.comission/comission-payment-rules))

(defn recieve-payment
  "Handles new payment"
  ([payment]
   (recieve-payment payment payment-rules))
  ([payment rules]
   (let [product (:product payment)]
     (doall (map #(execute-action-rule-if-applies product %) rules)))))