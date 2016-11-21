(ns payment.rules.utils)

(defn execute-action-rule-if-applies
  [product rule]
  (let [rule-applies? (:activation-check rule)
        execute-rule (:activator rule)]
    (when (rule-applies? product)
      (execute-rule product))))

(defn execute-chain-rule-if-applies
  [product previous-result rule]
  (let [rule-applies? (:activation-check rule)
        execute-rule (:activator rule)]
    (if (rule-applies? product)
      (execute-rule product previous-result)
      previous-result)))

(defn build-chained-rule
  [activation-check activator]
  {:activation-check (fn [product] (activation-check product))
   :activator        (fn [product previous-result] (activator product previous-result))})

(defn build-action-rule
  [activation-check activator]
  {:activation-check (fn [product] (activation-check product))
   :activator        (fn [product] (activator product))})

(defn build-chained-rules
  "Sequentialy executes applicable rules and passes result along."
  [& chained-rules]
  {:activation-check (constantly true)
   :activator        (fn [product]
                       (loop [remaining-rules chained-rules
                              rule-result {}]
                         (if-not (empty? remaining-rules)
                           (let [[rule & rest] remaining-rules]
                             (recur rest (execute-chain-rule-if-applies product
                                                                        rule-result
                                                                        rule))))))})