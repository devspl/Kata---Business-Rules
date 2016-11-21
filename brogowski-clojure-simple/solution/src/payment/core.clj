(ns payment.core)
(use 'payment.rules.utils)
(require '[payment.rules.membership :as membership])
(require '[payment.rules.packaging :as packaging])
(require '[payment.rules.comission :as comission])

(def payment-rules
  (concat membership/payment-rules
          packaging/payment-rules
          comission/payment-rules))

(defn recieve-payment
  "Handles new payment"
  ([payment]
   (recieve-payment payment payment-rules))
  ([payment rules]
   (let [product (:product payment)]
     (doall (map #(execute-action-rule-if-applies product %) rules)))))